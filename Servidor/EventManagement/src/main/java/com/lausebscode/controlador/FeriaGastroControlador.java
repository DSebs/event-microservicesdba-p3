package com.lausebscode.controlador;


import com.lausebscode.dto.FeriaGastroDTO;
import com.lausebscode.modelo.FeriaGastro;
import com.lausebscode.servicio.FeriaGastroServicio;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/feriagastro")
public class FeriaGastroControlador {

    @Autowired
    private FeriaGastroServicio feriaGastroServicio;

    @PostMapping("/crear")
    public ResponseEntity<FeriaGastroDTO> crearFeriaGastro(@RequestBody FeriaGastroDTO feriaGastroDTO) {
        try {
            FeriaGastroDTO feriaGastroCreada = feriaGastroServicio.crearFeriaGastro(feriaGastroDTO);
            return ResponseEntity.status(HttpStatus.CREATED).body(feriaGastroCreada);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/buscar/{id}")
    public ResponseEntity<FeriaGastroDTO> buscarFeriaGastroId(@PathVariable int id) {
        try {
            FeriaGastroDTO feriaGastro = feriaGastroServicio.buscarPorIdDTO(id);
            return ResponseEntity.ok(feriaGastro);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @GetMapping("/buscar/nombre/{nombre}")
    public ResponseEntity<FeriaGastroDTO> buscarFeriaGastroNombre(@PathVariable String nombre) {
        try {
            FeriaGastroDTO feriaGastro = feriaGastroServicio.buscarPorNombre(nombre);
            return ResponseEntity.ok(feriaGastro);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/eliminar/{id}")
    public ResponseEntity<Void> eliminarFeriaGastro(@PathVariable int id) {
        try {
            feriaGastroServicio.eliminarFeriaGastro(id);
            return ResponseEntity.noContent().build();
        } catch (IllegalArgumentException e) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(null);
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(null);
        }
    }

    @GetMapping("/listar")
    public ResponseEntity<List<FeriaGastroDTO>> listarTodasLasFeriasGastro() {
        List<FeriaGastroDTO> feriasGastro = feriaGastroServicio.listarTodasLasFeriasGastro();
        return ResponseEntity.ok(feriasGastro);
    }

    @GetMapping("/listar/precio/{precioMaximo}")
    public ResponseEntity<List<FeriaGastroDTO>> listarFeriasGastroMenorIgualPrecio(@PathVariable double precioMaximo) {
        List<FeriaGastroDTO> feriasGastro = feriaGastroServicio.listarFeriasGastroMenorIgualPrecio(precioMaximo);
        return ResponseEntity.ok(feriasGastro);
    }


    @PutMapping("/{id}")
    public ResponseEntity<FeriaGastroDTO> actualizarFeriaGastro(
            @PathVariable("id") int id,
            @RequestBody FeriaGastroDTO feriaGastroDTO) {
        try {
            FeriaGastroDTO feriaGastroActualizada = feriaGastroServicio.actualizarFeriaGastro(id, feriaGastroDTO);
            return ResponseEntity.ok(feriaGastroActualizada);
        } catch (IllegalArgumentException e) {
            return ResponseEntity.notFound().build();
        }
    }
}