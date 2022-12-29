import { Route, Routes } from "react-router-dom";
import {Home, Route as HomeRoute} from "./home/Home";
import { YayModalContainer } from "./shared/yay-modal/YayModalContainer";
import Footer from "./layout/Footer";
import Header from "./layout/Header";

const App = () => {
    return (
        <div className={"app"}>
            <YayModalContainer/>
            <Header/>
            <Routes>
                <Route path={HomeRoute} element={<Home/>}/>
            </Routes>
            <Footer/>
        </div>
    );
};

export default App;