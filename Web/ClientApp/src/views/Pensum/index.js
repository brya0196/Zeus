import React, {Fragment, useEffect} from 'react';
import {connect} from 'react-redux';
import {mostrarCursos} from '../../redux/actions/cursosActions';

import Periods from "../../components/Period";

function Cursos(props) {
    const {mostrarCursos} = props;

    useEffect(() => {
        mostrarCursos();
    }, [mostrarCursos]);

    const {title: mainTitle, cursos: {list, isFetching}} = props;
    const isEmpty = !isFetching && list.length === 0;

    return (
        <Fragment>
            <header className="page-header">
                <h2>{mainTitle}</h2>
            </header>
            <section className="mx-5">

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
export default connect(mapStateToProps, {mostrarCursos})(Cursos);
