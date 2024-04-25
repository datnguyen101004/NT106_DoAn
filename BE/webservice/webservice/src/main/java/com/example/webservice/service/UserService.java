package com.example.webservice.service;

import com.example.webservice.dto.CreateRoomDto;
import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.dto.UserDto;

public interface UserService {
    String changPassword(UserChangePassword userChangePassword);

    String createRoom(CreateRoomDto createRoomDto) throws Exception;

    String joinRoom(UserDto userDto) throws Exception;
}
