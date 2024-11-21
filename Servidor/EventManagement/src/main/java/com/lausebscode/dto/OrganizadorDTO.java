package com.lausebscode.dto;

import lombok.Data;

import java.time.LocalDateTime;

@Data
public class OrganizadorDTO {
    private int id;
    private String nombre;
    private double presupuesto;
    private LocalDateTime fundacion;
    private String ceo;
    private int feriaGastroId;
}
