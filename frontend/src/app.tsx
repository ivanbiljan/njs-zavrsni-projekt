import { Route, Routes } from "react-router-dom";
import {Home, Route as HomeRoute} from "./home/Home";
import { YayModalContainer } from "./shared/yay-modal/YayModalContainer";
import {Login, LoginRoute, Register, RegisterRoute} from "./authentication";

const App = () => {
    return (
        <div className={"app"}>
            <YayModalContainer/>
            <Routes>
                <Route path={RegisterRoute} element={<Register/>}/>
                <Route path={LoginRoute} element={<Login/>}/>
                <Route path={HomeRoute} element={<Home/>}/>
            </Routes>
        </div>
    );
};

export default App;