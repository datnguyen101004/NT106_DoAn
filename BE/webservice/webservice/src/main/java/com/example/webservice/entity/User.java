package com.example.webservice.entity;

import jakarta.persistence.*;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.List;


@Entity
@NoArgsConstructor
@AllArgsConstructor
@Data
@Table(name = "tb_user")
public class User{
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Username must not be empty")
    @Column(unique = true)
    private String username;

    @Email(message = "Email is not valid")
    @NotNull(message = "Email must not be empty")
    @Column(unique = true)
    private String email;

    @NotNull(message = "Password must not be empty")
    private String password;

    private boolean enable = false;

    @Column(name = "token")
    private String verifyToken;

    @Column(name = "win")
    private int matchWin;

    @Column(name = "lose")
    private int matchLose;

    private double money;

    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.ALL, mappedBy = "userList")
    private List<Room> roomList;
}
