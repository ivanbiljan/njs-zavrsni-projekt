import { ModalDataBase } from "./ModalDataBase";
import { AnyAction, createSlice, PayloadAction } from "@reduxjs/toolkit";

type Modal = (props: ModalDataBase) => JSX.Element;

export interface ShowModalPayload<T extends ModalDataBase> {
    modal: Modal;
    actionContext: T;
}

interface ModalState {
    modalDescriptors: ShowModalPayload<ModalDataBase>[];
}

const state: ModalState = {
    modalDescriptors: []
};

const slice = createSlice({
    name: "modal",
    initialState: state,
    reducers: {
        showModal<T extends ModalDataBase>(state: ModalState, action: PayloadAction<ShowModalPayload<T>>): void {
            state.modalDescriptors.push({
                modal: action.payload.modal,
                actionContext: action.payload.actionContext
            });
        },

        hideModal(state: ModalState): void {
            state.modalDescriptors.pop();
        }
    }
});

// https://stackoverflow.com/questions/51197819/declaring-const-of-generic-type/51197906
export const showModal: <T extends ModalDataBase = ModalDataBase>(modal: Modal, args: T) => AnyAction = (
    modal: Modal,
    args: any
) => slice.actions.showModal({ modal: modal, actionContext: args });
export const { hideModal } = slice.actions;

const { reducer } = slice;

export default reducer;