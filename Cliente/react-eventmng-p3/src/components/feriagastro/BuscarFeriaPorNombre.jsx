import React, { useState } from 'react';
import { buscarFeriaGastroPorNombre } from '../../services/feriaGastroService';

const BuscarFeriaNombre = () => {
  const [nombre, setNombre] = useState('');
  const [feria, setFeria] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const resultado = await buscarFeriaGastroPorNombre(nombre);
      setFeria(resultado);
    } catch (error) {
      alert('Error al buscar feria gastronómica: ' + error.message);
    }
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card">
            <div className="card-body">
              <h2 className="card-title text-center mb-4">Buscar Feria por Nombre</h2>
              <form onSubmit={handleSubmit}>
                <div className="mb-3">
                  <input
                    type="text"
                    className="form-control"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                    placeholder="Digite el Nombre de la Feria"
                    required
                  />
                </div>
                <div className="d-grid">
                  <button type="submit" className="btn btn-primary">Buscar</button>
                </div>
              </form>
              {feria && (
                <div className="mt-4">
                  <h3>Resultado:</h3>
                  <p>ID: {feria.id}</p>
                  <p>Nombre: {feria.nombre}</p>
                  <p>Precio: {feria.precio}</p>
                  <p>Fecha de Realización: {new Date(feria.fechaRealizacion).toLocaleDateString()}</p>
                  <p>Tipo: {feria.tipo}</p>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BuscarFeriaNombre;
