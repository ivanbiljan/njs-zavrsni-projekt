import YayInput from "./../shared/yay-input/YayInput";
import YayButton from "./../shared/yay-button/YayButton";
import { useForm } from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import * as Yup from "yup";

export const Route = "/login";

export const Login = () => {
    const schema = Yup.object({
        email: Yup.string().email("The provided value is not a valid email").required("Email is required"),
        password: Yup.string().required("The password cannot be empty")
    })

    const { register, handleSubmit, formState: {errors} } = useForm({
        mode: "onBlur",
        resolver: yupResolver(schema)
    });

    const onSubmitHandler = (data: any) => {
        console.log("balls");
    }

    return (
        <form onSubmit={handleSubmit(onSubmitHandler)} className={"h-[100%] flex flex-col justify-center items-center px-[250px] gap-4"}>
            <YayInput type={"text"} readOnly={false} label={"Email"} error={(errors.email && errors.email.message) ? errors.email.message.toString() : ""} {...register("email")} />
            <YayInput type={"password"} readOnly={false} label={"Confirm password"} error={(errors.password && errors.password.message) ? errors.password.message.toString() : ""} {...register("password") }/>
            <YayButton htmlType={"submit"} text={"Login"} color={"purple"} className={"justify-self-end"} />
        </form>
    );
};