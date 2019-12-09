import React, {Component} from 'react';
import {getSelection} from "../../services";
import {Link} from "react-router-dom";

export default class agregarMareria extends Component {

    constructor(props) {
        super(props);
        this.guargarSeleccion = this.guargarSeleccion.bind(this);

        this.state = {
            data: {
            }
        };
    }
    componentDidMount() {
        //buscar todas las materias
        // getSelection(1)
        //     .then(({data}) =>{
        //         console.log(data)
        //
        //     })
        //     .catch((error) => {
        //
        //     });
    }
    guargarSeleccion(){
        console.log("guardar")
    }
    render() {
        const { title: mainTitle } = this.props;

        return (
            <>
                <header className="page-header">
                    <h2>{mainTitle}</h2>
                    <ul className="controls">
                        <li>
                            <Link to="agregarMateria" className="btn btn-secondary" onClick={this.guargarSeleccion}>
                                Guardar
                            </Link>
                        </li>
                    </ul>
                </header>
                <section className="dashboard">
                    <div className="container-fluid">
                        <table className="table table-custom">
                            <thead>
                            <tr>
                                <th></th>
                                <th>Código</th>
                                <th>Nombre</th>
                                <th>Prerrequisito</th>
                            </tr>
                            </thead>
                            <tbody>
                            <tr>
                                <td className="controls">
                                    <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="customCheck1"/>
                                        <label className="custom-control-label" htmlFor="customCheck1"></label>
                                    </div>
                                </td>
                                <td>DER-313</td>
                                <td>Derechos Intelectuales</td>
                                <td>CodeRequirement</td>
                            </tr>
                            <tr>
                                <td className="controls">
                                    <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="customCheck1"/>
                                        <label className="custom-control-label" htmlFor="customCheck1"></label>
                                    </div>
                                </td>
                                <td>DER-313</td>
                                <td>Derechos Intelectuales</td>
                                <td>CodeRequirement</td>
                            </tr>
                            <tr>
                                <td className="controls">
                                    <div className="custom-control custom-checkbox">
                                        <input type="checkbox" className="custom-control-input" id="customCheck1"/>
                                        <label className="custom-control-label" htmlFor="customCheck1"></label>
                                    </div>
                                </td>
                                <td>DER-313</td>
                                <td>Derechos Intelectuales</td>
                                <td>CodeRequirement</td>
                            </tr>
                            </tbody>
                        </table>
                    </div>
                </section>
            </>
        )
    }
}