import { ModalDataBase } from "./ModalDataBase";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "./../Store";
import { showModal, ShowModalPayload } from "./ReduxSlice";

interface TestProps extends ModalDataBase {

}

const TestComp = () => {
    return (
        <>
            <div>BALLS3</div>
        </>
    );
};

export const YayModalContainer = () => {
    const { modalDescriptors } = useSelector((state: RootState) => state.modal);
    const dispatch = useDispatch();

    if (modalDescriptors.length === 0) {
        dispatch(
            showModal<TestProps>(TestComp, { title: "BALLS3666" }),
        );
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