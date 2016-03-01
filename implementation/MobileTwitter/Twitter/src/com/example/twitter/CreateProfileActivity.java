package com.example.twitter;


import java.sql.SQLException;

import android.app.Activity;
import android.app.ActionBar;
import android.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;
import android.os.Build;
import java.sql.ResultSet;

public class CreateProfileActivity extends Activity {

	

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_create_profile);
		
				
		if (savedInstanceState == null) {
			getFragmentManager().beginTransaction()
					.add(R.id.container, new PlaceholderFragment()).commit();
			
			// On clicking the register button perform validation and store in the DB.
			Button register_button = (Button)findViewById(R.id.submit);
			register_button.setOnClickListener(new OnClickListener() {
				
				public void onClick(View v) {
					
					// Get the values of all text fields.
					EditText uname = (EditText)findViewById(R.id.uname);
					String username = uname.getText().toString();
							
					EditText pass = (EditText)findViewById(R.id.pwd_text);
					String password = pass.getText().toString();
					
					EditText confirm = (EditText)findViewById(R.id.confirmText);
					String confirmPass = confirm.getText().toString();
					
					EditText secq = (EditText)findViewById(R.id.secq);
					String securityQ = secq.getText().toString();
							
					EditText seca = (EditText)findViewById(R.id.seca);
					String securityA = seca.getText().toString();
					
					// Check if all fields are entered.
					if(username.isEmpty() || password.isEmpty() || securityQ.isEmpty() || securityA.isEmpty())
					{
						Toast.makeText(CreateProfileActivity.this, "Please fill all the fields", Toast.LENGTH_LONG).show();
						return;
					}
					
					// Verify if password & confirm password.
					if(! password.equals(confirmPass))
					{
						Toast.makeText(CreateProfileActivity.this, "Password & Confirm pass don't match.", Toast.LENGTH_LONG).show();
						return;
					}
					
					Intent i = new Intent(v.getContext(), LoginActivity.class);
					startActivity(i);
					
				
				}
			});
			
			
		}
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.create_profile, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}

	/**
	 * A placeholder fragment containing a simple view.
	 */
	public static class PlaceholderFragment extends Fragment {

		public PlaceholderFragment() {
		}

		@Override
		public View onCreateView(LayoutInflater inflater, ViewGroup container,
				Bundle savedInstanceState) {
			View rootView = inflater.inflate(R.layout.activity_create_profile,
					container, false);
			return rootView;
		}
	}
}
