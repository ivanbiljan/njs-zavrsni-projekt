import { Route, Routes } from "react-router-dom";
import {Home, Route as HomeRoute} from "./home/Home";
import { YayModalContainer } from "./shared/yay-modal/YayModalContainer";

const App = () => {
    return (
        <div className={"app"}>
            <YayModalContainer/>
            <Routes>
                <Route path={HomeRoute} element={<Home/>}/>
            </Routes>
        </div>
    );
};

export default App;