package com.lausebscode.modelo;

import com.fasterxml.jackson.annotation.JsonBackReference;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.PastOrPresent;
import jakarta.validation.constraints.PositiveOrZero;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;
import java.time.LocalDateTime;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
@SuperBuilder
public class Organizador {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @NotBlank(message = "El nombre no puede estar vacío")
    private String nombre;

    @NotNull
    @PositiveOrZero(message = "El presupuesto no puede ser negativo")
    private double presupuesto;

    @NotNull
    @PastOrPresent(message = "La fecha de fundación no puede ser futura")
    private LocalDateTime fundacion;

    @NotBlank(message = "El CEO no puede estar vacío")
    private String ceo;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "feria_gastro_id")
    @JsonBackReference
    private FeriaGastro feriaGastro;
}