import React, { useState } from 'react';
import { agregarFeriaGastro } from '../../services/feriaGastroService';

const AgregarFeriaGastro = () => {
  const [feria, setFeria] = useState({
    id: '',
    nombre: '',
    precio: '',
    fechaRealizacion: '',
    tipo: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFeria(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    // Aseguramos que la fecha tiene el formato correcto (YYYY-MM-DDTHH:mm:ss)
    const fechaAjustada = feria.fechaRealizacion.includes(":") ? feria.fechaRealizacion + ":00" : feria.fechaRealizacion;
    const feriaAjustada = { ...feria, fechaRealizacion: fechaAjustada };
  
    try {
      await agregarFeriaGastro(feriaAjustada);
      alert('Feria agregada exitosamente');
    } catch (error) {
      alert('Error al agregar feria: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Agregar Feria</h2>
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    name="id"
                    value={feria.id}
                    onChange={handleChange}
                    placeholder="ID"
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="text"
                    className="form-control"
                    name="nombre"
                    value={feria.nombre}
                    onChange={handleChange}
                    placeholder="Nombre"
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    name="precio"
                    value={feria.precio}
                    onChange={handleChange}
                    placeholder="Precio"
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="datetime-local"
                    className="form-control"
                    name="fechaRealizacion"
                    value={feria.fechaRealizacion}
                    onChange={handleChange}
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="text"
                    className="form-control"
                    name="tipo"
                    value={feria.tipo}
                    onChange={handleChange}
                    placeholder="Tipo de comida"
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">Agregar</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AgregarFeriaGastro;
