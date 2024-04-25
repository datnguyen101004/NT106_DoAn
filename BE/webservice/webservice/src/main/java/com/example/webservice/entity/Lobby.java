package com.example.webservice.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.ArrayList;
import java.util.List;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
@Table(name = "tb_lobby")
public class Lobby {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private boolean exist = false;

    @OneToMany(fetch = FetchType.EAGER, mappedBy = "lobby", cascade = CascadeType.ALL)
    private List<Room> roomList = new ArrayList<>();
}
