
package com.mantegral.Headtrack_UDP;
import com.mantegral.Headtrack_UDP.UDP_Service;

import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.widget.TextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.CheckBox;
import android.widget.SeekBar;
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

	CheckBox kalman;
	CheckBox mean;

	EditText address;
	EditText port;

	static SharedPreferences pref;
	static Editor editor;

	static Context ctx;

	TextView tYaw;
	TextView tPitch;
	TextView tRoll;

	DecimalFormat df = new DecimalFormat("#.00"); 

	SeekBar timeSlider;
	TextView timeLabel;

    public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		button = findViewById(R.id.button);
		address = findViewById(R.id.addressEditText);
		port = findViewById(R.id.portEditText);

		kalman = findViewById(R.id.kalman);
		mean = findViewById(R.id.mean);
		timeSlider = findViewById(R.id.time);
		timeLabel = findViewById(R.id.timeLabel);

		tYaw   = findViewById(R.id.rX);
		tPitch = findViewById(R.id.rY);
		tRoll  = findViewById(R.id.rZ);

		pref = getApplicationContext().getSharedPreferences("Address", 0);
		editor = pref.edit();

		kalman.setChecked(pref.getBoolean("kalman", false));
		mean.setChecked(pref.getBoolean("mean", false));

		address.setText(pref.getString("ip", "0.0.0.0"));

		int portNumber = pref.getInt("port", 4242);
		port.setText(String.valueOf(portNumber));

		timeSlider.setProgress(pref.getInt("time", 15));
        timeLabel.setText(String.valueOf((float)timeSlider.getProgress() / 100.f) + " s");

		button.setBackgroundColor(Color.GREEN);
		button.setText("Start");

		ctx = this;

		button.setOnClickListener( new OnClickListener() {            
				@Override
				public void onClick(View v) {
					if(running){
						running = false;

						kalman.setEnabled(true);
						timeSlider.setEnabled(true);
						mean.setEnabled(true);
						
						((Button)v).setBackgroundColor(Color.GREEN);
						((Button)v).setText("Start");
						stopService(new Intent(ctx, UDP_Service.class));  
					}else{
						running = true;
						((Button)v).setBackgroundColor(Color.RED);
						((Button)v).setText("Stop");
						
						kalman.setEnabled(false);
						timeSlider.setEnabled(false);
						mean.setEnabled(false);
						UDP_Service.useKalman = kalman.isChecked();
						UDP_Service.useMean = mean.isChecked();
						UDP_Service.strAddress = address.getText().toString();
						UDP_Service.time = timeSlider.getProgress();

						editor.putString("ip", address.getText().toString());
						editor.putBoolean("kalman", kalman.isChecked());	
						editor.putBoolean("mean", mean.isChecked());	
						editor.putInt("time", timeSlider.getProgress());			
						try {  
							UDP_Service.port = Integer.parseInt(port.getText().toString());  
							editor.putInt("port", Integer.parseInt(port.getText().toString()));
						} catch (NumberFormatException e) {}  
						editor.commit();

						startService(new Intent(ctx, UDP_Service.class)); 
					}
				}
		});


		timeSlider.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                timeLabel.setText(String.valueOf((float)progress / 100.f) + " s");
            }

            public void onStartTrackingTouch(SeekBar seekBar) {
            }

            public void onStopTrackingTouch(SeekBar seekBar) {
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
