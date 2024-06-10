package com.example.webservice.service;

import com.example.webservice.dto.CreateRoomDto;
import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.dto.JoinRoomDto;
import com.example.webservice.entity.User;

import java.util.List;

public interface UserService {
    String changPassword(UserChangePassword userChangePassword);

    String createRoom(CreateRoomDto createRoomDto) throws Exception;

    String joinRoom(JoinRoomDto joinRoomDto) throws Exception;

    List<CreateRoomDto> getAllRoom();

    String win(String username, int type) throws Exception;

    String lose(String username, int type) throws Exception;

    double getMoney(String username);
}
