package com.example.corelia;

import static android.view.View.*;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

public class profile extends AppCompatActivity {

    TextView tvUsername, tvEmail, tvFname, tvLname;
    Button btnLogout;
    DataBase db;

    @SuppressLint("SetTextI18n")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_profile);

        db = new DataBase(this);
        tvUsername = findViewById(R.id.tv_username);
        tvEmail = findViewById(R.id.tv_email);
        tvFname = findViewById(R.id.tv_fname);
        tvLname = findViewById(R.id.tv_lname);
        btnLogout = findViewById(R.id.btn_logout);

        String email = getIntent().getStringExtra("usernameEmail");
        Cursor cursor = db.getUserDetails(email);

        if (cursor != null && cursor.moveToFirst()) {
            @SuppressLint("Range") String username = cursor.getString(cursor.getColumnIndex("username"));
            @SuppressLint("Range") String fname = cursor.getString(cursor.getColumnIndex("fname"));
            @SuppressLint("Range")  String lname = cursor.getString(cursor.getColumnIndex("lname"));

            tvUsername.setText("Username: " + username);
            tvEmail.setText("Email: " + email);
            tvFname.setText("First Name: " + fname);
            tvLname.setText("Last Name: " + lname);

            cursor.close();
        } else {
            Toast.makeText(profile.this, "Failed to retrieve user details", Toast.LENGTH_SHORT).show();
        }

        btnLogout.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(profile.this, login.class);
                startActivity(intent);

            }
        });
    }
}
