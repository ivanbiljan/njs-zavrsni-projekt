import { useNavigate } from "react-router-dom";
import YayInput from "@shared/yay-input/YayInput";
import YayButton from "@shared/yay-button/YayButton";
import { useForm } from "react-hook-form";
import {yupResolver} from "@hookform/resolvers/yup";
import * as Yup from "yup";
import {Route as LoginRoute} from "./Login";

export const Route = "/register";

export const Register = () => {
    const navigate = useNavigate();

    const validationSchema = Yup.object({
        email: Yup.string().email("The provided value is not a valid email").required("This field is required"),
        username: Yup.string().required("This field is required"),
        firstName: Yup.string().required("This field is required"),
        lastName: Yup.string().required("This field is required"),
        password: Yup.string().required("The password cannot be empty").matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$/, "Must contain at least one lowercase and uppercase letter and a number").min(5, "Must be at least 5 characters long"),
        confirmPassword: Yup.string().oneOf([Yup.ref("password")], "Passwords do not match")
    })

    const { register, handleSubmit, formState: {errors} } = useForm({
        mode: "onBlur",
        reValidateMode: "onBlur",
        resolver: yupResolver(validationSchema)
    });

    const onSubmitHandler = (data: any) => {
        console.log("balls");
        navigate(LoginRoute);
    }

    return (
        <form onSubmit={handleSubmit(onSubmitHandler)} className={"h-[100%] flex flex-col justify-center items-center px-[250px] gap-4"}>
            <YayInput type={"text"} readOnly={false} label={"Email"} error={(errors.email && errors.email.message) ? errors.email.message.toString() : ""} {...register("email")} />
            <YayInput type={"text"} readOnly={false} label={"Username"} error={(errors.username && errors.username.message) ? errors.username.message.toString() : ""} {...register("username")} />
            <YayInput type={"text"} readOnly={false} label={"First name"} error={(errors.firstName && errors.firstName.message) ? errors.firstName.message.toString() : ""} {...register("firstName")} />
            <YayInput type={"text"} readOnly={false} label={"Last name"} error={(errors.lastName && errors.lastName.message) ? errors.lastName.message.toString() : ""} {...register("lastName")} />
            <YayInput type={"password"} readOnly={false} label={"Password"} error={(errors.password && errors.password.message) ? errors.password.message.toString() : ""} {...register("password") }/>
            <YayInput type={"password"} readOnly={false} label={"Confirm password"} error={(errors.confirmPassword && errors.confirmPassword.message) ? errors.confirmPassword.message.toString() : ""} {...register("confirmPassword") }/>
            <YayButton htmlType={"submit"} text={"Register"} color={"purple"} className={"md: w-[240px]"} />
        </form>
    );
};