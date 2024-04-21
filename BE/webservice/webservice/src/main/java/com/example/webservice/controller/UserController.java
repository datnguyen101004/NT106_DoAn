package com.example.webservice.controller;

import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.service.AuthService;
import com.example.webservice.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequiredArgsConstructor
@RequestMapping("/user")
@CrossOrigin
public class UserController {
    private final UserService userService;

    @PostMapping("/changePassword")
    public ResponseEntity<String> changePassword(@RequestBody UserChangePassword userChangePassword){
        return ResponseEntity.ok().body(userService.changPassword(userChangePassword));
    }
}
