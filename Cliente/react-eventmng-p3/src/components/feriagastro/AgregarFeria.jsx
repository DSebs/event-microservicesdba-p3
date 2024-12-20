import React, { useState } from 'react';
import { agregarFeriaGastro } from '../../services/feriaGastroService';

const AgregarFeriaGastro = () => {
  const [feria, setFeria] = useState({
    id: '',
    nombre: '',
    precio: '',
    fechaRealizacion: '',
    tipo: '',
    organizadorIds: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFeria(prev => ({ ...prev, [name]: value }));
  };

  const handleOrganizadorIdsChange = (e) => {
    const { value } = e.target;
    setFeria(prev => ({ ...prev, organizadorIds: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    // Aseguramos que la fecha tiene el formato correcto (YYYY-MM-DDTHH:mm:ss)
    const fechaAjustada = feria.fechaRealizacion.includes(":") ? feria.fechaRealizacion + ":00" : feria.fechaRealizacion;
    
    // Convertir organizadorIds a array de números, permitiendo array vacío
    const organizadorIdsArray = feria.organizadorIds.trim() !== '' 
      ? feria.organizadorIds.split(',')
          .map(id => id.trim())
          .filter(id => id !== '')
          .map(Number)
          .filter(id => !isNaN(id))
      : [];

    const feriaAjustada = { 
      ...feria, 
      fechaRealizacion: fechaAjustada,
      organizadorIds: organizadorIdsArray
    };
  
    try {
      await agregarFeriaGastro(feriaAjustada);
      alert('Feria agregada exitosamente');
      // Limpiar el formulario después de agregar exitosamente
      setFeria({
        id: '',
        nombre: '',
        precio: '',
        fechaRealizacion: '',
        tipo: '',
        organizadorIds: ''
      });
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
                <div className="mb-3">
                  <input
                    type="text"
                    className="form-control"
                    name="organizadorIds"
                    value={feria.organizadorIds}
                    onChange={handleOrganizadorIdsChange}
                    placeholder="IDs de organizadores (separados por coma)"
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
