import React, {Component} from 'react';
import {getSelectionCar,addSelection} from "../../services";
import {date} from "../../helpers"
export default class agregarMareria extends Component {

    constructor(props) {
        super(props);
        this.guargarSeleccion = this.guargarSeleccion.bind(this);
        this.handleCBChange = this.handleCBChange.bind(this);
        
        this.state = {
            isLoading: true,
            selected:[],
            seleccions: [],
            error: null
        }
    }
    componentDidMount() {
        //buscar todas las seleccions
        getSelectionCar()
            .then(({data}) =>{
                this.setState({seleccions: data})
            })
            .catch((error) => {

            })
            .finally(()=>{
                this.setState({isLoading:false})
            })
    }
    handleCBChange(e) {
        const item = e.target.name;
        const isChecked = e.target.checked;

        let selected = this.state.selected;

        if (isChecked)
            selected.push(item);
        else
            selected = selected.filter(mat => mat !== item);

        this.setState({ selected });
    }
    guargarSeleccion(){
        this.setState({isLoading:true})
        let seleccions = this.state.selected.map(function(i){
            return parseInt(i, 10);
        });
        
        addSelection(seleccions)
            .then(({data}) =>{
               this.props.history.push('/seleccion');
            })
            .catch((error) => {
                this.setState({isLoading:false, error: error.response.data})
            })
    }
    render() {
        const { title: mainTitle } = this.props;
        const { seleccions, selected, isLoading } = this.state;

        return (
            <>
                {isLoading &&
                    <div className="loading"></div>
                }
                <header className="page-header">
                    <h2>{mainTitle}</h2>
                    <ul className="controls">
                        <li>
                            <button to="agregarMateria" className="btn btn-secondary" disabled={selected.length <= 0}
                                  onClick={this.guargarSeleccion}> Guardar
                            </button>
                        </li>
                    </ul>
                </header>
                
                
                
                <section className="dashboard">
                    <div className="container-fluid">
                        <div className={(this.state.error) ? 'alert alert-danger': null}>{this.state.error}</div>
                        
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
                                {seleccions.length > 0 && seleccions.map(sec=>
                                    <tr key={sec.id}>
                                        <td className="controls">
                                            <div className="custom-control custom-checkbox">
                                                <input type="checkbox"
                                                       name={sec.id}
                                                       checked={selected.includes(sec.id.toString())}
                                                       className="custom-control-input" id={sec.id}
                                                       onChange={this.handleCBChange}
                                                />
                                                <label className="custom-control-label" htmlFor={sec.id}></label>
                                            </div>
                                        </td>
                                        <td>{sec.subject.code}</td>
                                        <td>{sec.subject.name}</td>
                                        <td>{sec.maximumRoom}</td>
                                        <td>{sec.days}</td>
                                        <td>{date(sec.timeEnds,"h:m a")} - {date(sec.timeStart,"h:m a")}</td>
                                        <td>{date(sec.dateStart)} - {date(sec.dateEnds)}</td>

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