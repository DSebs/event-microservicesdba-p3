package com.lausebscode.servicio;

import com.lausebscode.dto.FeriaGastroDTO;
import com.lausebscode.modelo.FeriaGastro;
import java.util.List;

public interface FeriaGastroServicio {
    FeriaGastroDTO crearFeriaGastro(FeriaGastroDTO feriaGastroDTO);
    FeriaGastro buscarPorId(int id);
    FeriaGastro buscarPorNombre(String nombre);
    void eliminarFeriaGastro(int id);
    List<FeriaGastroDTO> listarTodasLasFeriasGastro();
    List<FeriaGastroDTO> listarFeriasGastroMenorIgualPrecio(double precioMaximo);
    FeriaGastroDTO actualizarFeriaGastro(int id, FeriaGastroDTO feriaGastroDTO);
}