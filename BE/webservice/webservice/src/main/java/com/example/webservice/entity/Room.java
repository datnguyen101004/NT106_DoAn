package com.example.webservice.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.util.ArrayList;
import java.util.List;

@Entity
@NoArgsConstructor
@AllArgsConstructor
@Data
@Table(
        name = "tb_room"
)
public class Room {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(unique = true)
    private String roomId;
    private boolean enable;
    @Column(name = "type")
    private int typeMoney;

    @ManyToMany(fetch = FetchType.LAZY, cascade = {CascadeType.PERSIST, CascadeType.MERGE})
    @JoinTable(name = "room_user", joinColumns = @JoinColumn(name = "room_id", referencedColumnName = "id"),
                                    inverseJoinColumns = @JoinColumn(name = "user_id", referencedColumnName = "id"))
    private List<User> userList = new ArrayList<>();

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "list_room_id")
    private Lobby lobby;

}
