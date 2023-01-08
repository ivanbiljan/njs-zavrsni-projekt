import { useQuery } from "react-query";
import Api from "./../ApiHelpers";
import { CategoryDto } from "@shared/api/categories/Responses";

const endpoints = {
    getAll: "/api/categories",
}

const queryKey = "categories";

const useCategories = () => {
    return useQuery(queryKey, async () => await Api.get<CategoryDto[]>(endpoints.getAll));
}

export {useCategories};