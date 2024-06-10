package com.example.webservice.controller;

import com.example.webservice.dto.CreateRoomDto;
import com.example.webservice.dto.RoomDto;
import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.dto.JoinRoomDto;
import com.example.webservice.entity.User;
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
    public ResponseEntity<String> joinRoom(@RequestBody JoinRoomDto joinRoomDto) throws Exception {
        return ResponseEntity.ok().body(userService.joinRoom(joinRoomDto));
    }

    @GetMapping("/allRoom")
    public ResponseEntity<List<CreateRoomDto>> getAllRoom(){
        return ResponseEntity.ok().body(userService.getAllRoom());
    }

    @PostMapping("/{username}/win")
    public ResponseEntity<String> win(@PathVariable String username, @RequestBody RoomDto roomDto) throws Exception {
        return ResponseEntity.ok(userService.win(username, roomDto.getType()));
    }

    @PostMapping("/{username}/lose")
    public ResponseEntity<String> lose(@PathVariable String username, @RequestBody RoomDto roomDto) throws Exception {
        return ResponseEntity.ok(userService.lose(username, roomDto.getType()));
    }

    @GetMapping("/info")
    public ResponseEntity<Double> getMoney(@RequestParam("username") String username){
        return ResponseEntity.ok(userService.getMoney(username));
    }
}
