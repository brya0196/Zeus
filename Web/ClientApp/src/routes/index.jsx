import Cursos from '../views/Cursos';
import DashBoard from '../views/DashBoard';

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
    //Cursos
    {
        path: "/cursos",
        title: "Lista de cursos",
        component: Cursos
    },
    { redirect: true, path: "/", to: "/Dashboard", title: "Redirect" }
];
export default routes;
