import React, { useState } from 'react';
import { agregarOrganizador } from '../../services/organizadorService';

const AgregarOrganizador = () => {
  const [organizador, setOrganizador] = useState({
    id: '',
    nombre: '',
    presupuesto: '',
    fundacion: '',
    ceo: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setOrganizador(prev => ({ ...prev, [name]: name === 'presupuesto' ? parseFloat(value) : value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Asegurarse de que la fecha de fundación tenga el formato correcto (YYYY-MM-DDTHH:mm:ss)
    const fechaAjustada = organizador.fundacion.includes(":") ? organizador.fundacion + ":00" : organizador.fundacion;

    const organizadorAjustado = {
      ...organizador,
      fundacion: fechaAjustada
    };

    try {
      await agregarOrganizador(organizadorAjustado);
      alert('Organizador agregado exitosamente');
      
      // Limpiar el formulario después de agregar exitosamente
      setOrganizador({
        id: '',
        nombre: '',
        presupuesto: '',
        fundacion: '',
        ceo: ''
      });
    } catch (error) {
      alert('Error al agregar organizador: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Agregar Organizador</h2>
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    name="id"
                    value={organizador.id}
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
                    value={organizador.nombre}
                    onChange={handleChange}
                    placeholder="Nombre"
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="number"
                    className="form-control"
                    name="presupuesto"
                    value={organizador.presupuesto}
                    onChange={handleChange}
                    placeholder="Presupuesto"
                    step="0.1"
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="datetime-local"
                    className="form-control"
                    name="fundacion"
                    value={organizador.fundacion}
                    onChange={handleChange}
                    required
                  />
                </div>
                <div className="mb-3">
                  <input
                    type="text"
                    className="form-control"
                    name="ceo"
                    value={organizador.ceo}
                    onChange={handleChange}
                    placeholder="CEO"
                    required
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

export default AgregarOrganizador;
