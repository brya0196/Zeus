import Pensum from '../views/Pensum';
import DashBoard from '../views/DashBoard';
import Seleccion from '../views/SeleccionMateria';
import AgregarMareria from '../views/SeleccionMateria/agregar';
import InfoPersonal from '../views/InfoPersonal';

import NotFound_404 from '../views/404';

const routes = [
    {
        path: "/404",
        sidebarName: "404",
        title: "404",
        component: NotFound_404
    },
    {
        path: "/DashBoard",
        component: DashBoard
    },
    //seleccion
    {
        path: "/seleccion",
        title: "Preselección",
        component: Seleccion
    },
    {
        path: "/agregarMateria",
        title: "Agregar Materia",
        component: AgregarMareria
    },
    //Cursos
    {
        path: "/pensum",
        title: "Pensum",
        component: Pensum
    },
    //InfoPersonal
    {
        path: "/InfoPersonal",
        title: "Información Personal",
        component: InfoPersonal
    },
    { redirect: true, path: "/", to: "/Dashboard", title: "Redirect" }
];
export default routes;
