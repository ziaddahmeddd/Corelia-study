package com.example.task1;

import android.os.Bundle;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class ProfileActivity extends AppCompatActivity {

    TextView tvWelcome, tvEmail, tvFullName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        tvWelcome = findViewById(R.id.tvWelcome);
        tvEmail = findViewById(R.id.tvEmail);
        tvFullName = findViewById(R.id.tvFullName);

        // Retrieve data from the intent
        String username = getIntent().getStringExtra("USERNAME");
        String email = getIntent().getStringExtra("EMAIL");
        String fname = getIntent().getStringExtra("FNAME");
        String lname = getIntent().getStringExtra("LNAME");

        // Display user information
        tvWelcome.setText("Welcome, " + username);
        tvEmail.setText("Email: " + email);
        tvFullName.setText("Name: " + fname + " " + lname);
    }
}
