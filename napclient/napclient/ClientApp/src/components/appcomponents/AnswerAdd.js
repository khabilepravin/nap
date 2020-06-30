import React, {useState} from "react";
import { useForm } from "react-hook-form";
import * as Yup from "yup";
import axios from "axios";

import { Form, FormGroup, Input, Label, Button, CustomInput } from "reactstrap";

import {
  faSave,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { toastr } from "react-redux-toastr";

const schema = Yup.object().shape({
  questionId: Yup.string().required("QuestionId is required"),
  text: Yup.string().required("Name is required"),
  description: Yup.string().required("Description is required"),
  sequence: Yup.string().required("Sequence is required"),
});

const AnswerAdd = (props) => {
  const questionId = props.questionId;
  const [imageFile, setImageFile] = useState();
  const { register, handleSubmit, reset, errors } = useForm({
    validationSchema: schema,
  });
  const onSubmit = (data) => {
    submitAnswerForm(data);
  };
  
  const onImageAttached = (e) => {
    setImageFile(e.target.files[0]);
  };

  const submitAnswerForm = (data) => {   
    let formData = new FormData();

    formData.set("answer", JSON.stringify(data));
    formData.append("imageFile", imageFile);

    axios
      .post(`${process.env.REACT_APP_REST_API_ENDPOINT}/answer`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then((response) => {
        console.log(response);
        if (response.status !== 500) {
          reset();
          showToastr("Success", "Answer added successfully");
          props.onAnswerAdded();
        }
      });
  };

  const showToastr = (title, message) => {
    const options = {
      timeOut: parseInt(3000),
      showCloseButton: false,
      progressBar: true,
      position: "top-right",
    };

    const toastrInstance = toastr.success;
    toastrInstance(title, message, options);
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <FormGroup>
        <Label>Name</Label>
        <Input type="text" name="text" placeholder="Name" innerRef={register} />
        {errors.text && <p className="text-danger">{errors.text.message}</p>}
      </FormGroup>
      <FormGroup>
        <Label>Sequence</Label>
        <Input
          type="number"
          name="sequence"
          placeholder="Sequence"
          rows="1"
          innerRef={register}
        />
        {errors.sequence && (
          <p className="text-danger">{errors.sequence.message}</p>
        )}
      </FormGroup>
      <FormGroup>
        <Label>Description</Label>
        <Input
          type="textarea"
          id="description"
          name="description"
          className="mb-3"
          innerRef={register}
        ></Input>
        {errors.description && (
          <p className="text-danger">{errors.description.message}</p>
        )}
      </FormGroup>
      <FormGroup>
        <CustomInput
          type="checkbox"
          id="isCorrect"
          name="isCorrect"
          label="Is The Right Answer"
          innerRef={register}
          className="mb-2"
        />
      </FormGroup>
      <FormGroup>
      <Label>Image</Label>
        <Input
          type="file"
          id="imageFile"
          onChange={onImageAttached}
          name="imageFile"
        />
      </FormGroup>
      <Input
        type="hidden"
        id="questionId"
        name="questionId"
        value={questionId}
        innerRef={register}
      ></Input>
      <Button type="submit" color="primary" className="mr-1 mb-1">
        <FontAwesomeIcon icon={faSave} /> Save and Reset
      </Button>
    </Form>
  );
};

export default AnswerAdd;
