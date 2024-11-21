import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import { Navbar, Nav, NavDropdown, Container } from 'react-bootstrap';
import Home from './components/home/Home';  
import AgregarFeria from './components/feriagastro/AgregarFeria';
import ActualizarFeria from './components/feriagastro/ActualizarFeria';
import BuscarFeriaGastroID from './components/feriagastro/BuscarFeriaPorId';
import BuscarFeriaNombre from './components/feriagastro/BuscarFeriaPorNombre';
import EliminarFeria from './components/feriagastro/EliminarFeria';
import ListarFeria from './components/feriagastro/ListarFeria';
import AgregarOrganizador from './components/organizadores/AgregarOrg';
import ActualizarOrganizador from './components/organizadores/ActualizarOrg';
import BuscarOrganizadorID from './components/organizadores/BuscarOrgPorId';
import BuscarOrganizadorNombre from './components/organizadores/BuscarOrgPorNombre';
import EliminarOrganizador from './components/organizadores/EliminarOrg';
import ListarOrganizadores from './components/organizadores/ListarOrg';
import AcercaDe from './components/ayuda/AcercaDe';


function App() {
  return (
    <Router>
      <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand as={Link} to="/">EventManagement</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <NavDropdown title="Feria Gastronomica" id="feria-dropdown">
                <NavDropdown.Item as={Link} to="/agregar-feria">Agregar Feria</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/buscar-feria-id">Buscar Feria Por ID</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/buscar-feria-nombre">Buscar Feria Por Nombre</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/actualizar-feria">Actualizar Feria</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/eliminar-feria">Eliminar Feria</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/listar-feria">Listar Feria</NavDropdown.Item>
              </NavDropdown>
              <NavDropdown title="Organizador" id="organizador-dropdown">
                <NavDropdown.Item as={Link} to="/agregar-org">Agregar Organizacion</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/buscar-org-id">Buscar Organizacion Por ID</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/buscar-org-nombre">Buscar Organizacion Por Nombre</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/actualizar-org">Actualizar Organizacion</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/eliminar-org">Eliminar Organizacion</NavDropdown.Item>
                <NavDropdown.Item as={Link} to="/listar-org">Listar Organizacion</NavDropdown.Item>
              </NavDropdown>
              <NavDropdown title="Ayuda" id="ayuda-dropdown">
                <NavDropdown.Item as={Link} to="/acerca-de">Acerca de ...</NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/agregar-feria" element={<AgregarFeria />} />
        <Route path="/buscar-feria-id" element={<BuscarFeriaGastroID />} />
        <Route path="/buscar-feria-nombre" element={<BuscarFeriaNombre />} />
        <Route path="/actualizar-feria" element={<ActualizarFeria />} />
        <Route path="/eliminar-feria" element={<EliminarFeria />} />
        <Route path="/listar-feria" element={<ListarFeria />} />
        <Route path="/agregar-org" element={<AgregarOrganizador />} />
        <Route path="/buscar-org-id" element={<BuscarOrganizadorID />} />
        <Route path="/buscar-org-nombre" element={<BuscarOrganizadorNombre />} />
        <Route path="/actualizar-org" element={<ActualizarOrganizador />} />
        <Route path="/eliminar-org" element={<EliminarOrganizador />} />
        <Route path="/listar-org" element={<ListarOrganizadores />} />
        <Route path="/acerca-de" element={<AcercaDe />} />
      </Routes>
    </Router>
  );
}

export default App;
