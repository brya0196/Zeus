import React, {useEffect, Fragment} from 'react';
import {connect} from 'react-redux';
import {agregarEditarCurso, eliminarCurso, mostrarCursos, toggleModal} from '../../redux/actions/cursosActions';

import Swal from 'sweetalert2';
import Subject from "../../components/Subject";
import Periods from "../../components/Period";

function Cursos(props) {
    const {mostrarCursos} = props;

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

    const {title: mainTitle, cursos: {list, isFetching, showModal, byId, isPending, error}} = props;
    const isEmpty = !isFetching && list.length === 0;

    console.log(list);

    return (
        <Fragment>
            <header className="page-header">
                <h2>{mainTitle}</h2>
            </header>
            <section className="cursos">

                {!isEmpty && list.map((item, index) =>
                    (<Periods key={index} pensum={item}/>)
                )}
                {isEmpty && <div className="isEmpty">No se encontraron registros</div>}
            </section>
        </Fragment>
    );

}

const mapStateToProps = (state) => ({
    cursos: state.cursos
});
export default connect(mapStateToProps, {mostrarCursos, agregarEditarCurso, eliminarCurso, toggleModal})(Cursos);
