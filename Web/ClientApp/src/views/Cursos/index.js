import React, { useEffect} from 'react';
import { MostrarError } from "../../components/MostrarError";
import { connect } from 'react-redux';
import { mostrarCursos, agregarEditarCurso, eliminarCurso, toggleModal } from '../../redux/actions/cursosActions';

import Swal from 'sweetalert2';
import { Crear } from './crear';

function Cursos(props) {
    const { mostrarCursos } = props;
     useEffect(() => {
        mostrarCursos();
     }, [mostrarCursos]);

    const delItem = id => {


        Swal.fire({
            html: "&iquest;Estas seguro de querer eliminar este servicio?",
            showCancelButton: true,
            focusCancel: true,
            confirmButtonText: 'Eliminar!',
            showLoaderOnConfirm: true,
            preConfirm: () => {
                return props.eliminarCurso(id)
            }
        })

    };

     const { title: mainTitle, cursos: { list, isFetching, showModal, byId, isPending,error } } = props;
     const isEmpty = !isFetching && list.length === 0;

      return (
          <>
              <header className="page-header">
                  <h2>{mainTitle}</h2>
                  <ul className="controls">
                      <li>
                          <button className="btn btn-secondary" onClick={props.toggleModal}>
                              Agregar
                          </button>
                      </li>
                  </ul>
              </header>
              <section className="cursos">
                  <div className="container-fluid">
                      <MostrarError errors={error} />
                      <div className="table-responsive">
                          {isFetching && !list.length &&
                              <div className="loading"></div>
                          }
                          <table className='table table-custom'>
                              <thead>
                                  <tr>
                                      <th></th>
                                      <th>Descripción</th>
                                  </tr>
                              </thead>
                              <tbody>
                                  {!isEmpty && list.map(item => 
                                      <tr key={item.id}>
                                          <td className="controls">
                                              <button className="text-primary" type="button" onClick={() => props.toggleModal(item.id)} ><div className="icon icon-android-create" aria-hidden="true"></div></button>
                                              <button className="text-danger" type="button" onClick={() => delItem(item.id)}><div className="icon icon-android-close" aria-hidden="true"></div></button>
                                          </td >
                                          <td>{item.des}</td>
                                          <td>{item.id}</td>
                                      </tr>
                                  )}
                              </tbody>
                          </table>
                          {isEmpty && <div className="isEmpty">No se encontraron registros</div>}
                      </div>
                  </div>
                  <Crear open={showModal} itemToEdit={byId} onReset={props.toggleModal}
                      onSubmit={props.agregarEditarCurso} loading={isPending}/>
              </section>
          </>
        );

}

const mapStateToProps = (state) => ({
    cursos: state.cursos
});
export default connect(mapStateToProps, { mostrarCursos, agregarEditarCurso, eliminarCurso, toggleModal })(Cursos);
