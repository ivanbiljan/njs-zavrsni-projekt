import { ModalDataBase } from "./ModalDataBase";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "./../Store";
import { showModal, ShowModalPayload } from "./ReduxSlice";

export const YayModalContainer = () => {
    const { modalDescriptors } = useSelector((state: RootState) => state.modal);

    if (modalDescriptors.length === 0) {
        return <></>;
    }

    return (
        <>
            {modalDescriptors.map((value: ShowModalPayload<ModalDataBase>, index) => {
                const Modal = value.modal;
                return <Modal {...value.actionContext} />;
            })}
        </>
    );
};