import axios, { AxiosError, AxiosRequestConfig, AxiosResponse } from "axios";
import { toast } from "react-toastify";
import { devConsoleError, devConsoleLog } from "./../helperFunctions";

export interface YayAxiosResponse<T = any, D = any> extends AxiosResponse<T, D> {
    config: YayAxiosRequestConfig<D>;
}

export interface YayAxiosError<T = any, D = any> extends AxiosError<T, D> {
    config: YayAxiosRequestConfig<D>;
    response: YayAxiosResponse<T, D>;
}

export interface YayAxiosRequestConfig<D = any> extends AxiosRequestConfig<D> {
    successMessage?: string;
    errorMessage?: string;
}

// if (process.env.BE_ENV === "localhost") {
//     axios.defaults.baseURL = `https://localhost:${process.env.BE_PORT}`;
// } else {
//     axios.defaults.baseURL = ""; // production
// }

axios.defaults.baseURL = `https://localhost:${process.env.BE_PORT}`;

// Add a request interceptor
axios.interceptors.request.use(
    function (config) {
        // Do something before request is sent
        devConsoleLog(`REQUEST : ${config.url}\n\nJSON : ${JSON.stringify(config)}`);

        return config;
    },
    function (error) {
        // Do something with request error
        devConsoleLog(`API request error : ${JSON.stringify(error)}`);

        return Promise.reject(error);
    }
);

// Add a response interceptor
axios.interceptors.response.use(
    function (response: YayAxiosResponse) {
        devConsoleLog(
            `RESPONSE : ${response.config.url} - Status : ${response.status} \n\nJSON : ${JSON.stringify(response)}`
        );

        if (response.config.successMessage != undefined) {
            toast.success(response.config.successMessage);
        }

        return response;
    },
    function (error: YayAxiosError) {
        // Do something with response error
        if (error.response) {
            if (error.response.config.errorMessage != undefined) {
                toast.error(error.response.config.errorMessage);
            }
            devConsoleError(`API response error : ${JSON.stringify(error.response)}`);
        } else {
            if (error.config.errorMessage != undefined) {
                toast.error(error.config.errorMessage);
            }
            devConsoleError(`API response error : ${JSON.stringify(error)}`);
        }

        return Promise.reject({
            name: error.name,
            message: error.response?.data.Message,
            code: error.response?.status?.toString(),
            stack: error.stack,
        });
    }
);

export default axios;