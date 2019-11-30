import React, {useState, useEffect} from 'react';
import { Alert } from 'react-bootstrap';

// import PropTypes from 'prop-types';

export function MostrarError(props) {
    const { errors, fixed=true} = props;
    const [mensaje, setMensaje] = useState("");
    const [errorsList, setErrorsList] = useState([]);
    useEffect(() => {
        if (errors && errors.data) {
            let tipo = typeof errors.data;

            if (tipo === "string"){
               setMensaje(errors.data)

            }else if (tipo === "object"){
                let { title, errors: errores, contrato, error, inquilino} = errors.data;
                if (title){
                    setMensaje(title);
                    setErrorsList(errores)
                } else if (contrato){
                    setMensaje(error);
                    setErrorsList({ Inquilino: inquilino, Contrato: contrato})
                }

            }
        }

    }, [setErrorsList, setMensaje, errors]);

        return (
            <Alert show={mensaje.length > 0} variant="danger" onClose={() => setMensaje("")} dismissible className={fixed?"fixed":""}>
                {mensaje}
                {Object.keys(errorsList).length > 0 &&                
                    <ul>
                        {Object.keys(errorsList).map(key=>
                            <li key={key}>{key} : {(typeof errorsList[key] === "object") ? errorsList[key].join(" / ") : errorsList[key]}</li>   
                        )}
                    </ul>
                }
            </Alert>
        );
}

// MostrarError.propTypes = {
//     errors: PropTypes.ojb,
// }