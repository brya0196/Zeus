import React, {useState, useEffect} from 'react';
import {Modal, Button, Spinner} from 'react-bootstrap';

export function Crear(props) {
    const [curso, setCurso] = useState();
    const {open, itemToEdit} = props;
    useEffect(() => {
        if (open) {
            if (Object.keys(itemToEdit).length && itemToEdit.id !== curso.id) {
                //     setCurso(itemToEdit)
            }
        } else {
           // setCurso({id: null, des: ""})
        }

    }, [curso,setCurso, open, itemToEdit]);

    const handleSubmit = e => {
        e.preventDefault();
        props.onSubmit(curso)
    };

    const toEdit = !!Object.keys(props.itemToEdit).length;
    return (
        <>
            <Modal show={props.open} onHide={props.onReset}>
                <form onSubmit={handleSubmit}>
                    <Modal.Header closeButton>
                        <Modal.Title>{toEdit ? "Actualizar" : "Agregar Nuevo"}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        Contenido
                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="danger" onClick={props.onReset}>
                            Cancelar
                        </Button>
                        <Button type="submit" variant="primary" disabled={props.loading}>
                            {props.loading && <Spinner
                                as="span"
                                animation="border"
                                size="sm"
                                role="status"
                                aria-hidden="true"
                            />}
                            {toEdit ? " Actualizar" : " Guardar"}
                        </Button>
                    </Modal.Footer>
                </form>
            </Modal>
        </>
    );

}
