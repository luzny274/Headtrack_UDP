package com.mantegral.Headtrack_UDP;

import java.net.*;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.util.concurrent.CyclicBarrier;
import java.lang.Thread.*;
  
import android.app.Service;  
import android.content.Intent;  
import android.media.MediaPlayer;  
import android.os.IBinder;  
import android.widget.Toast;  

import com.kircherelectronics.fsensor.filter.averaging.MeanFilter;
import com.kircherelectronics.fsensor.observer.SensorSubject;
import com.kircherelectronics.fsensor.sensor.FSensor;
import com.kircherelectronics.fsensor.sensor.gyroscope.ComplementaryGyroscopeSensor;
import com.kircherelectronics.fsensor.sensor.gyroscope.KalmanGyroscopeSensor;
  
public class UDP_Service extends Service {  

	public static String strAddress = ""; static int port = 5555;
	public static Boolean useKalman = false;
	public static Boolean useMean = false;
	public static float time = 0.15f;

	static CyclicBarrier sync;
	Thread worker;
	static volatile Boolean running = false;

	private static DatagramSocket socket;
	private static InetAddress address; 

	private FSensor fSensor;
    private MeanFilter meanFilter;

	static ByteBuffer buf;
	public static double[] dbs = new double[6];

	@Override
	public IBinder onBind(Intent intent) {
		return null;
	}

    @Override  
    public void onCreate() {  
        Toast.makeText(this, "Service Created", Toast.LENGTH_SHORT).show();

		buf = ByteBuffer.allocate(49);
		buf.order(ByteOrder.LITTLE_ENDIAN);

		if(useKalman)
			fSensor = new KalmanGyroscopeSensor(this);
		else{
			fSensor = new ComplementaryGyroscopeSensor(this);
			((ComplementaryGyroscopeSensor)fSensor).setFSensorComplimentaryTimeConstant(time);
		}

		if(useMean){
			meanFilter = new MeanFilter();
			meanFilter.setTimeConstant(time);
		}

		sync = new CyclicBarrier(2);

		worker = new Thread(new Runnable() { 
			public void run(){
			running = true;
			try {
				while(running) {
					Thread.sleep(7);

					try {
					sync.await();
					} catch(Exception e) {}
					
					send();
				}
			} catch (InterruptedException e) {}
			}
		});	

    }  

    @Override  
    public void onStart(Intent intent, int startid) {  
        Toast.makeText(this, "Service Started", Toast.LENGTH_SHORT).show();  

		try {
		socket = new DatagramSocket();	
		address = InetAddress.getByName(strAddress);
		}
		catch(SocketException e) {
		} catch(UnknownHostException e) {
		} 

        fSensor.register(sensorObserver);
        fSensor.start();
		worker.start();

    }  

    @Override  
    public void onDestroy() {  
        Toast.makeText(this, "Service Stopped", Toast.LENGTH_SHORT).show();  

		running = false;
		fSensor.unregister(sensorObserver);
		fSensor.stop();

		socket.close();
    }  

	private SensorSubject.SensorObserver sensorObserver = new SensorSubject.SensorObserver() {
		@Override
		public void onSensorChanged(float[] values) {
			dbs[0] = 0.0; dbs[1] = 0.0; dbs[2] = 0.0; 
			float[] vals;
			if(useMean)
				vals = meanFilter.filter(values);
			else
				vals = values;

			dbs[3] = ((double)Math.toDegrees(vals[0]) + 360.0) % 360.0 - 180.0;
			dbs[4] = ((double)Math.toDegrees(vals[1]) + 360.0) % 360.0 - 180.0;
			dbs[5] = ((double)Math.toDegrees(vals[2]) + 360.0) % 360.0 - 180.0;

			if(sync.getNumberWaiting() > 0)
				sync.reset();	
		}
    };

	public static void send() {
		buf.clear();	
		for(double d : dbs)
			buf.putDouble(d);
	      				
		byte[] arr = buf.array();

		try {
			DatagramPacket packet = new DatagramPacket(arr, arr.length, address, port);
			socket.send(packet);
		}
		catch(SocketException e) {
		}catch(IOException e) {
		}
	 }

}  

