package com.example.webservice.service.impl;

import com.example.webservice.dto.CreateRoomDto;
import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.dto.JoinRoomDto;

import com.example.webservice.entity.Room;
import com.example.webservice.entity.User;
import com.example.webservice.repository.RoomRepository;
import com.example.webservice.repository.UserRepository;
import com.example.webservice.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
@RequiredArgsConstructor
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;
    private final RoomRepository roomRepository;

    @Override
    public String changPassword(UserChangePassword userChangePassword) {
        Optional<User> user = userRepository.findByUsername(userChangePassword.getUsername());
        if (user.isPresent()){
            User _user = user.get();
            _user.setPassword(userChangePassword.getPassword());
            userRepository.save(_user);
            return "Password change successfully";
        }
        return "Error";
    }

    @Override
    public String createRoom(CreateRoomDto createRoomDto) throws Exception {
        try {
            User user = userRepository.findByUsername(createRoomDto.getUsername()).orElseThrow(() -> new Exception("Cannot find username"));
            Room room = new Room();
            room.setRoomId(createRoomDto.getRoomId());
            room.setEnable(true);
            room.setTypeMoney(createRoomDto.getTypeMoney());
            List<User> userList = new ArrayList<>();
            userList.add(user);
            room.setUserList(userList);
            roomRepository.save(room);
            return "New room is created";
        }
        catch (Exception e){
            return "Error";
        }
    }

    @Override
    public String joinRoom(JoinRoomDto joinRoomDto) throws Exception {
        User user = userRepository.findByUsername(joinRoomDto.getUsername()).orElseThrow(() -> new Exception("Cannot find username"));
        Room room = roomRepository.findByRoomId(joinRoomDto.getRoomId());
        room.getUserList().add(user);
        roomRepository.save(room);
        return joinRoomDto.getUsername() + "join room successfully";
    }

    @Override
    public List<CreateRoomDto> getAllRoom() {
        List<Room> roomList = roomRepository.findAll();
        List<CreateRoomDto> createRoomDtoList = new ArrayList<>();
        for (Room room : roomList){
            CreateRoomDto roomDto = new CreateRoomDto();
            roomDto.setRoomId(room.getRoomId());
            roomDto.setTypeMoney(room.getTypeMoney());
            roomDto.setNumberPeople(room.getUserList().size());
            createRoomDtoList.add(roomDto);
        }
        return createRoomDtoList;
    }
}
