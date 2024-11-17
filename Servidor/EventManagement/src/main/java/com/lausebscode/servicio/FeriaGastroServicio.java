package com.lausebscode.servicio;

import com.lausebscode.dto.FeriaGastroDTO;
import com.lausebscode.modelo.FeriaGastro;
import java.util.List;

public interface FeriaGastroServicio {
    FeriaGastroDTO crearFeriaGastro(FeriaGastroDTO feriaGastroDTO);
    FeriaGastro buscarPorId(int id);
    FeriaGastro buscarPorNombre(String nombre);
    void eliminarFeriaGastro(FeriaGastro feriaGastro);
    List<FeriaGastro> listarTodasLasFeriasGastro();
    List<FeriaGastro> listarFeriasGastroMenorIgualPrecio(double precioMaximo);
    FeriaGastroDTO actualizarFeriaGastro(int id, FeriaGastroDTO feriaGastroDTO);
}