import React, { useState } from "react";
import { useForm } from "react-hook-form";
import * as Yup from "yup";
import ReactQuill from "react-quill";
import { Form, FormGroup, Input, Label, Button } from "reactstrap";

import { faSave } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { toastr } from "react-redux-toastr";
import axios from "axios";

const schema = Yup.object().shape({
  testId: Yup.string().required("TestId is required"),
  description: Yup.string().required("Description is required"),
  sequence: Yup.string().required("Sequence is required"),
  questionType: Yup.string().required("Question Type is required"),
});

const QuestionAdd = (props) => {
  const [testId, setTestId] = useState(props.testId);
  const [questionText, setQuestionText] = useState();
  const [imageFile, setImageFile] = useState();
  const [questionObj, setQuestionObj] = useState();

  const { register, handleSubmit, reset, errors } = useForm({
    validationSchema: schema,
  });

  const onSubmit = (data) => {
    if (!questionText) {
      showToastr("Danger", "Question Text is required");
    }

    data.text = questionText;
    submitQuestionForm(data);
  };

  const submitQuestionForm = (data) => {
    console.log(JSON.stringify(data));
    let formData = new FormData();

    formData.set("question", JSON.stringify(data));
    formData.append("imageFile", imageFile);

    axios
      .post(`${process.env.REACT_APP_REST_API_ENDPOINT}/question`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then((response) => {
        if (response.status !== 500) {
          reset();
          showToastr("Success", "Question added successful");
          props.questionAdded();
        }
      });
  };

  const onImageAttached = (e) => {
    setImageFile(e.target.files[0]);
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

  const handleQuestionTextChange = (content) => {
    setQuestionObj({ ...questionObj }, { questionText: content });
    setQuestionText(content);
  };

  return (
    <Form onSubmit={handleSubmit(onSubmit)}>
      <FormGroup>
        <Label>Question Text</Label>
        <ReactQuill
          placeholder="Questquestion Text"
          id="text"
          name="text"
          innerRef={register}
          onChange={handleQuestionTextChange}
        />
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
        <Label>Question Type</Label>
        <Input
          type="select"
          id="questionTypeSelect"
          name="questionType"
          className="mb-3"
          innerRef={register}
        >
          <option value="">Question Type</option>
          <option value="multi">Multi Select</option>
          <option value="single">Single Select</option>
          <option value="text">Text</option>
          <option value="image">Image</option>
        </Input>
        {errors.questionType && (
          <p className="text-danger">{errors.questionType.message}</p>
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
        id="testId"
        name="testId"
        value={testId}
        innerRef={register}
      ></Input>
      <Button type="submit" color="primary" className="mr-1 mb-1">
        <FontAwesomeIcon icon={faSave} /> Add
      </Button>
    </Form>
  );
};

export default QuestionAdd;
