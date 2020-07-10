
package com.mantegral.Headtrack_UDP;
import com.mantegral.Headtrack_UDP.UDP_Service;

import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.widget.TextView;
import android.widget.Button;
import android.widget.EditText;
import android.graphics.Color;
import android.view.View;
import android.view.View.OnClickListener;
import android.content.*;
import android.content.SharedPreferences.Editor;

import java.text.DecimalFormat;
import java.lang.Thread.*;


public class Headtrack_UDP_Activity extends Activity {
	Button button;
	static Boolean running = false;

	EditText address;
	EditText port;

	static SharedPreferences pref;
	static Editor editor;

	static Context ctx;

	TextView tYaw;
	TextView tPitch;
	TextView tRoll;

	DecimalFormat df = new DecimalFormat("#.00"); 


    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        button = findViewById(R.id.button);
        address = findViewById(R.id.addressEditText);
        port = findViewById(R.id.portEditText);

	tYaw   = findViewById(R.id.rX);
	tPitch = findViewById(R.id.rY);
	tRoll  = findViewById(R.id.rZ);

	pref = getApplicationContext().getSharedPreferences("Address", 0);
	editor = pref.edit();

	address.setText(pref.getString("ip", "0.0.0.0"));

	int portNumber = pref.getInt("port", 4242);
	port.setText(String.valueOf(portNumber));

	button.setBackgroundColor(Color.GREEN);
	button.setText("Start");

	ctx = this;

	button.setOnClickListener( new OnClickListener() {            
            @Override
            public void onClick(View v) {
		if(running){
			running = false;
			((Button)v).setBackgroundColor(Color.GREEN);
			((Button)v).setText("Start");
			stopService(new Intent(ctx, UDP_Service.class));  
		}else{
			running = true;
			((Button)v).setBackgroundColor(Color.RED);
			((Button)v).setText("Stop");
			
			UDP_Service.strAddress = address.getText().toString();
			editor.putString("ip", address.getText().toString());
			try {  
				UDP_Service.port = Integer.parseInt(port.getText().toString());  
				editor.putInt("port", Integer.parseInt(port.getText().toString()));
			} catch (NumberFormatException e) {}  
			editor.commit();

			startService(new Intent(ctx, UDP_Service.class)); 
		}
            }
        });

	Thread uiThread = new Thread() {

	  @Override
	  public void run() {
	    try {
	      while (!Thread.currentThread().isInterrupted()) {
		Thread.sleep(50);
			runOnUiThread(new Runnable() {
			  @Override
			  public void run() {
				if(running){
					tYaw.setText(	"Yaw:"   + df.format(UDP_Service.dbs[3]));
					tPitch.setText(	"Pitch:" + df.format(UDP_Service.dbs[4]));
					tRoll.setText(	"Roll:"  + df.format(UDP_Service.dbs[5]));
				}else{
					tYaw.setText("");
					tPitch.setText("");
					tRoll.setText("");	
				}
			  }
			});
	      }
	    } catch (InterruptedException e) {
	    }
	  }
	};

	uiThread.start();
    }

}
