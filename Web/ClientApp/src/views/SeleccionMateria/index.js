import React, {Component} from 'react';
import {getSelection,delSelection} from "../../services";
import {Link} from "react-router-dom";
import Swal from "sweetalert2";
import {date} from "../../helpers";
export default class Seleccion extends Component {

    constructor(props) {
        super(props);
        this.eliminarMateria = this.eliminarMateria.bind(this);
        this.state = {
            isLoading: true,
            materias: []
        };
    }
    componentDidMount() {
        getSelection()
            .then(({data}) =>{
                this.setState({materias:data.subscriptionSections})
            })
            .catch((error) => {
                console.log(error.response)

            })
            .finally(()=>{
                this.setState({isLoading:false})
            })
    }
    eliminarMateria(id){

        Swal.fire({
            text: "¿Deseas eliminar esta materia?",
            showCancelButton: true,
        }).then((result) => {
            if (result.value) {
                delSelection(id)
                    .then(({data}) =>{
                        let materias = this.state.materias.filter(mat=> mat.id !== id);
                        this.setState({materias});
                    })
                    .catch((error) => {
                        console.log(error.response)
                    })
                    .finally(()=>{
                        this.setState({isLoading:false})
                    })
            }
        })
        

    }
    render() {
        const { title: mainTitle } = this.props;
        const { materias,isLoading } = this.state;

        return (
            <>
                {isLoading &&
                <div className="loading"></div>
                }
                <header className="page-header">
                    <h2>{mainTitle}</h2>
                    <ul className="controls">
                        <li>
                            <Link to="agregarMateria" className="btn btn-secondary">
                                Agregar
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
                                <th>Cupo</th>
                                <th>Días</th>
                                <th>Hora</th>
                                <th>Fecha</th>

                            </tr>
                            </thead>
                            <tbody>
                            {materias.length > 0 && materias.map(mat=>
                                <tr key={mat.section.id}>
                                    <td className="controls" onClick={()=>this.eliminarMateria(mat.id)}>
                                        <i className="fa fa-trash-o"></i>
                                    </td>
                                    <td>{mat.section.subject.code}</td>
                                    <td>{mat.section.subject.name}</td>
                                    <td>{mat.section.maximumRoom}</td>
                                    <td>{mat.section.days}</td>
                                    <td>{date(mat.section.timeEnds,"h:m a")} - {date(mat.section.timeStart,"h:m a")}</td>
                                    <td>{date(mat.section.dateStart)} - {date(mat.section.dateEnds)}</td>
                                </tr>
                            )}
                            </tbody>
                        </table>
                    </div>
                </section>
            </>
        )
    }
}