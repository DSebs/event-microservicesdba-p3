package com.lausebscode.servicio;

import com.lausebscode.modelo.FeriaGastro;

import java.util.List;

public interface FeriaGastroServicio {

    FeriaGastro crearFeriaGastro(FeriaGastro feriaGastro);
    FeriaGastro buscarPorId(int id);
    FeriaGastro buscarPorNombre(String nombre);
    void eliminarFeriaGastro(FeriaGastro feriaGastro);
    List<FeriaGastro> listarTodasLasFeriasGastro();
    List<FeriaGastro> listarFeriasGastroMenorIgualPrecio(double precioMaximo);
    FeriaGastro actualizarFeriaGastro(int id, FeriaGastro nuevoFeriaGastro);
    }