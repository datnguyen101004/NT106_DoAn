package com.example.webservice.controller;

import com.example.webservice.dto.CreateRoomDto;
import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.dto.UserDto;
import com.example.webservice.entity.Room;
import com.example.webservice.service.AuthService;
import com.example.webservice.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

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

    @PostMapping("/createRoom")
    public ResponseEntity<String> createRoom(@RequestBody CreateRoomDto createRoomDto) throws Exception {
        return ResponseEntity.ok().body(userService.createRoom(createRoomDto));
    }

    @PostMapping("/joinRoom")
    public ResponseEntity<String> joinRoom(@RequestBody UserDto userDto) throws Exception {
        return ResponseEntity.ok().body(userService.joinRoom(userDto));
    }

    @GetMapping("/allRoom")
    public ResponseEntity<List<CreateRoomDto>> getAllRoom(){
        return ResponseEntity.ok().body(userService.getAllRoom());
    }
}
