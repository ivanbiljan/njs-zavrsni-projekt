import { Route, Routes } from "react-router-dom";
import {Home, Route as HomeRoute} from "./home/Home";
import { YayModalContainer } from "./shared/yay-modal/YayModalContainer";
import Footer from "./layout/Footer";
import Header from "./layout/Header";
import { Login } from "./login/Login";

const App = () => {
    return (
        <div className={"app"}>
            <YayModalContainer/>
            <Routes>
                <Route path={HomeRoute} element={<Home/>}/>
                <Route path={"/login"} element={<Login/>}/>
            </Routes>
        </div>
    );
};

export default App;