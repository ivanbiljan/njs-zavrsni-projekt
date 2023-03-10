import "core-js/stable";
import "regenerator-runtime/runtime";
import {BrowserRouter} from "react-router-dom";
import { createRoot } from "react-dom/client";
import App from "./app";
import "./index.css";
import { Provider } from "react-redux";
import store from "./shared/Store";

const rootElement = document.getElementById("root")!;
const root = createRoot(rootElement);

root.render(
    <Provider store={store}>
        <BrowserRouter>
            <App/>
        </BrowserRouter>
    </Provider>
);