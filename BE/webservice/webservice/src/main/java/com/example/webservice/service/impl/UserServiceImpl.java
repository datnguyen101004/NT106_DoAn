package com.example.webservice.service.impl;

import com.example.webservice.dto.UserChangePassword;
import com.example.webservice.entity.User;
import com.example.webservice.repository.UserRepository;
import com.example.webservice.service.UserService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;

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
}
