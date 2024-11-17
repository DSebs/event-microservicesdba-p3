package com.lausebscode.dto;

import lombok.Data;
import java.time.LocalDateTime;
import java.util.List;

@Data
public class FeriaGastroDTO {
    private int id;
    private String nombre;
    private double precio;
    private LocalDateTime fechaRealizacion;
    private String tipo;
    private List<Integer> organizadorIds;
}