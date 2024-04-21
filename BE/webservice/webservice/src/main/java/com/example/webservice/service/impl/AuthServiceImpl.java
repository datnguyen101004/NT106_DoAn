package com.example.webservice.service.impl;

import com.example.webservice.dto.AuthRegisterDto;
import com.example.webservice.dto.AuthLoginDto;
import com.example.webservice.entity.User;
import com.example.webservice.repository.UserRepository;
import com.example.webservice.service.AuthService;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Objects;
import java.util.Optional;
import java.util.UUID;


@Service
@RequiredArgsConstructor
public class AuthServiceImpl implements AuthService {
    private final UserRepository userRepository;

    @Override
    public String register(AuthRegisterDto authRegisterDto) {
        try {
            User user = new User();
            user.setEmail(authRegisterDto.getEmail());
            user.setUsername(authRegisterDto.getUsername());
            user.setPassword(authRegisterDto.getPassword());
            user.setEnable(false);
            user.setMoney(10000);
            userRepository.save(user);
            return "User register successfully";
        }
        catch (Exception e){
            return e.getMessage();
        }
    }

    @Override
    public String verifyAccount(String token) {
        Optional<User> user = userRepository.findByVerifyToken(token);
        if (user.isPresent()){
            User _user = user.get();
            _user.setEnable(true);
            userRepository.save(_user);
            return "Account is verified";
        }
        return "Token is incorrect";
    }

    @Override
    public String createForgetPassword(String email) {
        Optional<User> user = userRepository.findByEmail(email);
        if (user.isPresent()){
            User _user = user.get();
            String password = UUID.randomUUID().toString();
            _user.setPassword(password);
            userRepository.save(_user);
            return "New password: "+password;
        }
        return "Email not found";
    }

    @Override
    public String login(AuthLoginDto authLoginDto) throws Exception {
        try {
            Optional<User> user = userRepository.findByEmail(authLoginDto.getEmail());
            if (user.isPresent()) {
                User _user = user.get();
                if (_user.isEnable() && Objects.equals(_user.getPassword(), authLoginDto.getPassword())) {
                    return "Login successfully";
                }
                return "Password is incorrect or account is not enable";
            } else {
                throw new Exception("Error with user is not exist");
            }
        } catch (Exception ex) {
            return ex.getMessage();
        }
    }
}
