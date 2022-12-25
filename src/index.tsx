import "core-js/stable";
import {render} from "react-dom";
import "regenerator-runtime/runtime";
import {BrowserRouter} from "react-router-dom";
import App from "./app";
import "./index.css";

const rootElement = document.getElementById("root");
render(
    <App/>, rootElement
);