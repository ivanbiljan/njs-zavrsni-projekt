import { combineReducers, configureStore } from "@reduxjs/toolkit";
import modalReducer from "./yay-modal/ReduxSlice";
import { useDispatch } from "react-redux";

export const store = configureStore({
    reducer: combineReducers({
        modal: modalReducer
    })
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();

export default store;