package com.lausebscode.modelo;

import com.fasterxml.jackson.annotation.JsonManagedReference;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.PositiveOrZero;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import lombok.experimental.SuperBuilder;
import java.time.LocalDateTime;
import java.util.List;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
@SuperBuilder
public class FeriaGastro {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @NotBlank(message = "El nombre no puede estar vacío")
    private String nombre;

    @NotNull
    @PositiveOrZero(message = "El precio no puede ser negativo")
    private double precio;

    @NotNull(message = "La fecha de realización no puede estar vacía")
    private LocalDateTime fechaRealizacion;

    @NotBlank(message = "El tipo no puede estar vacío")
    private String tipo;

    @OneToMany(mappedBy = "feriaGastro", cascade = {CascadeType.PERSIST, CascadeType.MERGE}, orphanRemoval = false)
    @JsonManagedReference
    private List<Organizador> organizadores;
}