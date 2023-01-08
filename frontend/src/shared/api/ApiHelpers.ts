import axios from "./AxiosClient";
import { AxiosRequestConfig } from "axios";
import qs from "qs";

const Api = {
    get: async <T>(url: string, params?: any): Promise<T | undefined> => {
        const config: AxiosRequestConfig = {
            responseType: "json",
            params: params,
            paramsSerializer: {
                serialize: p => qs.stringify(p)
            }
        }

        const response = await axios.get<T>(url, config);

        return response.data;
    }
}

export default Api;