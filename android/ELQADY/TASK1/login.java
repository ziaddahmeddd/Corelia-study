package com.example.corelia;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;

public class login extends AppCompatActivity {

    EditText etUsernameEmail, etPassword;
    Button btnLogin;
    TextView tvRegister;
    DataBase db;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        db = new DataBase(this);
        etUsernameEmail = findViewById(R.id.et_username_email);
        etPassword = findViewById(R.id.et_password);
        btnLogin = findViewById(R.id.btn_login);
        tvRegister = findViewById(R.id.tv_register);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String usernameEmail = etUsernameEmail.getText().toString();
                String password = etPassword.getText().toString();
                boolean isAuthenticated = db.authenticateUser(usernameEmail, password);

                if (isAuthenticated) {
                    Intent intent = new Intent(login.this, profile.class);
                    intent.putExtra("usernameEmail", usernameEmail);
                    startActivity(intent);
                } else {
                    Toast.makeText(login.this, "Invalid credentials", Toast.LENGTH_SHORT).show();
                }
            }
        });

        tvRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(login.this, MainActivity.class);
                startActivity(intent);
            }
        });
    }
}
