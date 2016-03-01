package com.example.twitter;

import android.app.Activity;
import android.app.ActionBar;
import android.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.os.Build;

public class HomeActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_home);
		
		findViewById(R.id.logout).setOnClickListener(
				new View.OnClickListener() {
					@Override
					public void onClick(View view) {
						// Call the home screen.
						Intent i = new Intent(HomeActivity.this, LoginActivity.class);
						startActivity(i);
						
					}
				});
		
		findViewById(R.id.changePass).setOnClickListener(
				new View.OnClickListener() {
					@Override
					public void onClick(View view) {
						// Call the home screen.
						Intent i = new Intent(HomeActivity.this, ChangePasswordActivity.class);
						startActivity(i);
						
					}
				});
		
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {

		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.home, menu);
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
	
}
